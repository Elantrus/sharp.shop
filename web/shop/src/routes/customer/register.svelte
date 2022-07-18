<script lang="ts">
	import Input from '$lib/components/ui/forms/input.svelte';
	import { CustomerService } from '$lib/services/customer';
	import { notifications } from '$lib/stores/notificationStore';
	import { AuthenticationService } from '$lib/services/authentication';
	import { credentials } from '$lib/stores/credentialsStore';
	import { fade } from 'svelte/transition';

	//Models
	import type { CreateCustomer } from '$lib/models/customer/createCustomer';
	import type { AuthenticationResult } from '$lib/models/authentication/authenticationResult';
	import type { CustomerAuthentication } from '$lib/models/customer/customerAuthentication';

	//Validators
	import {
		emailValidator,
		requiredValidator,
		passwordValidator
	} from '$lib/validators/validationHandlers';

	import { page } from '$app/stores';
	import { goto } from '$app/navigation';
	import { visitor } from '$lib/stores/visitorStore';
	import Form from '$lib/components/ui/forms/form.svelte';
	import Icon from '@iconify/svelte';

	export let query: URLSearchParams = $page.url.searchParams;

	let submitting = false;

	let createCustomerModel: CreateCustomer = {
		email: '',
		name: '',
		surName: '',
		password: ''
	};

	async function registerHandler() {
		CustomerService.create(createCustomerModel)
			.then((response) => {
				const loginCredentials: CustomerAuthentication = {
					email: createCustomerModel.email,
					password: createCustomerModel.password,
					deviceId: $visitor
				};

				AuthenticationService.login(loginCredentials)
					.then((authResponse) => {
						const data: AuthenticationResult = authResponse.data;
						credentials.set(data);

						let callBack = query.get('callback');

						goto(callBack ? callBack : '/');
					})
					.catch((error) => notifications.danger(error, 300));
			})
			.catch((error) => notifications.danger(error, 3000));
	}
</script>

<div in:fade={{duration:150}} out:fade={{duration:150}} class="flex flex-col gap-10 items-center min-h-full md:w-96 self-center">
	<div class="flex flex-col items-center">
		<h1 class="font-semibold text-xl">Creating a new account</h1>
		<p class="text-sm text-neutral-500 text-center">
			Provide some informations to create your new account. Already have an account? <a
				class="underline"
				href="/customer/login">Proceed to login</a
			>
		</p>
	</div>
	<Form submitHandler={registerHandler}>
		<Input
			bind:value={createCustomerModel.name}
			validators={[requiredValidator]}
			name="name"
			type="text">Name</Input
		>

		<Input
			bind:value={createCustomerModel.surName}
			validators={[requiredValidator]}
			name="surName"
			type="text">Surname</Input
		>

		<Input
			bind:value={createCustomerModel.email}
			validators={[emailValidator]}
			name="email"
			type="email">E-mail</Input
		>

		<Input
			bind:value={createCustomerModel.password}
			validators={[requiredValidator]}
			name="password"
			type="password">Password</Input
		>

		<button
			disabled={submitting}
			class="flex items-center gap-2 self-end rounded py-2 px-4 bg-neutral-800 disabled:bg-neutral-600 text-neutral-100 hover:disabled:cursor-not-allowed"
			type="submit"
		>
			{#if submitting}
				<Icon icon="lucide:loader" class="animate-spin" />
			{/if}
			Register
		</button>
	</Form>
</div>
