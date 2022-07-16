<script lang="ts">
	import '../app.css';
	import Icon from '@iconify/svelte';

	//Stores
	import { customer } from '$lib/stores/customerStore';
	import { credentials } from '$lib/stores/credentialsStore';

	import { theme } from '$lib/stores/themeStore';

	//Toast
	import Toast from '$lib/components/notification/toast.svelte';

	import { goto } from '$app/navigation';
	import { onMount } from 'svelte';
	import { CustomerService } from '$lib/services/customer';

    import {slide} from 'svelte/transition'

	let lowScreenSize = false;
	let showNavbar = false;

	onMount(() => {
		if ($customer) return;

		if ($credentials)
			CustomerService.get().then((response) => {
				customer.set(response.data);
			});

		const mediaListener = window.matchMedia('(max-width: 768px)');

		lowScreenSize = mediaListener.matches;

		mediaListener.addEventListener('change', mediaQueryHandler);
	});

	const mediaQueryHandler = (ev: MediaQueryListEvent) => {
		lowScreenSize = ev.matches;
	};

	function toggleNavbar() {
		showNavbar = !showNavbar;
	}

	function toggleDarkMode() {
		theme.update((current) => {
			return current === 'dark' ? 'light' : 'dark';
		});
	}

	function loginHandler() {
		if ($customer) {
			goto('/dashboard');
		} else {
			goto('/customer/login');
		}
	}
</script>

<template>
	<header class="flex justify-between md:items-center py-6 px-10 md:w-10/12 2xl:w-8/12 w-full">
		<div>
			<img src="/images/logo.png" alt="logo" />
		</div>
		<div>
			<nav class="flex flex-col justify-between items-end">
				<div class="md:flex flex-row-reverse gap-4 items-end text-sm">
					<div class="flex justify-end gap-2">
						{#if $customer}
							<div on:click={loginHandler} class="text-xl hover:cursor-pointer ">
								<Icon icon="bxs:user" />
							</div>
						{:else}
							<div>
								<button
									on:click={loginHandler}
									class="rounded bg-neutral-800 py-1 px-2 hover:bg-neutral-700 text-neutral-100"
								>
									Login
								</button>
							</div>
						{/if}

						<div
							class="hover:cursor-pointer text-2xl dark:text-yellow-600"
							on:click={toggleDarkMode}
						>
							<Icon icon="carbon:light-filled" />
						</div>

						{#if lowScreenSize}
							<div on:click={toggleNavbar} class="text-2xl hover:cursor-pointer">
								<Icon icon="dashicons:menu-alt" />
							</div>
						{/if}
					</div>
					{#if !lowScreenSize || (lowScreenSize && showNavbar)}
						<ul transition:slide class="flex justify-end flex-col md:flex-row text-end">
							<li
								class="rounded hover:bg-neutral-200 dark:hover:bg-neutral-800 hover:cursor-pointer"
							>
								<a class="block w-full h-full py-1 px-2" href="/">Home</a>
							</li>

							<li
								class="rounded hover:bg-neutral-200 dark:hover:bg-neutral-800 hover:cursor-pointer"
							>
								<a class="block w-full h-full py-1 px-2" href="/contact">Contact</a>
							</li>

							<li
								class="rounded hover:bg-neutral-200 dark:hover:bg-neutral-800 hover:cursor-pointer"
							>
								<a class="block w-full h-full py-1 px-2" href="/tracking">Tracking</a>
							</li>
						</ul>
					{/if}
				</div>
			</nav>
		</div>
	</header>
</template>

<main class="px-10 py-6 mx-auto md:w-10/12 2xl:w-8/12 h-screen w-full flex flex-col">
	<slot />
</main>

<footer class="py-5 px-6 text-sm h-32 md:h-64 w-full bg-neutral-800 flex justify-center text-neutral-200">
	<div class="w-2/3 h-full flex flex-col justify-between">
		<div class="flex justify-around">
			<div>
				<h1 class="text-lg">Sharpmeta @ 2022</h1>
				<div class="mt-2 text-neutral-200">
					<p>409 Groove Street, Apartment#20</p>
					<p> New York - United States</p>
				</div>
			</div>
			<div>
				<h5 class="text-lg">Contact us</h5>
				<div class="text-neutral-200 mt-2">
					<h5>+(00) 999-9999</h5>
					<button class="bg-white rounded text-neutral-800 p-1 mt-4 w-full">Chat now</button> 
				</div>
			</div>
			<div>
				<h5 class="text-lg">Follow us</h5>
				<div class="text-neutral-200">
					<div class="mt-2 flex gap-2">
						<Icon class="text-2xl" icon="ion:logo-twitter" />
						<span>Twitter</span>
					</div>
					<div class="mt-2 flex gap-2">
						<Icon class="text-2xl" icon="ion:logo-instagram" />
						<span>Instagram</span>
					</div>
					<div class="mt-2 flex gap-2">
						<Icon class="text-2xl" icon="ion:logo-tiktok" />
						<span>Tiktok</span>
					</div>
					
				</div>
			</div>
		</div>
		<hr class="border-b-violet-500 border-solid border-y-neutral-700" />
		<p class="text-white p-4 text-center">
			Made with <span class="text-red-600">♥</span> by <strong>lazaro@sharpmeta.xyz</strong>
		</p>
	</div>
	
</footer>

<Toast />
