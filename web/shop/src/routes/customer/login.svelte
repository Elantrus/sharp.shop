<script lang="ts">
    import { page } from '$app/stores'
    
    import type { CustomerAuthentication } from '$lib/models/customer/customerAuthentication';
    import { AuthenticationService } from "$lib/services/authentication";
    import { onMount } from "svelte";
    import { fade, fly, slide } from 'svelte/transition';
    import Form from '$lib/components/ui/forms/form.svelte';

    //stores
    import { visitor } from "$lib/stores/visitorStore";
    import {notifications } from "$lib/stores/notificationStore"
    import {credentials} from "$lib/stores/credentialsStore"
    import type { AuthenticationResult } from "$lib/models/authentication/authenticationResult";

    import Input from "$lib/components/ui/forms/input.svelte";
    import { goto } from "$app/navigation";
    import { emailValidator, passwordValidator } from '$lib/validators/validationHandlers';

    export let query : URLSearchParams = $page.url.searchParams;

    let loginData : CustomerAuthentication = {
        email: "",
        password: "",
        deviceId: $visitor
    };


    async function login(){
        await AuthenticationService.login(loginData).then((result)  => {
            const data : AuthenticationResult = result.data;
            credentials.set(data);

            let callBack = query.get("callback");

            goto(callBack ? callBack : "/");
        }).catch(error => notifications.danger(error, 3000));
    }

</script>

<div in:fade={{duration:150}} out:fade={{duration:150}} class="flex flex-col gap-10 items-center min-h-full md:w-96 self-center">
    <div class="flex flex-col items-center">
        <h1 class="font-semibold text-xl">Welcome!</h1>
        <p class="text-sm text-neutral-500 text-center">Sign-in using your credentials. Are you new here? <a class="underline" href="/customer/register">Create a new account</a></p>
    </div>
    <Form submitHandler={login}>
        <Input bind:value={loginData.email} validators={[emailValidator]} name="email" type="email">E-mail</Input>
        <Input bind:value={loginData.password} validators={[passwordValidator]} name="password" type="password">Password</Input>
        <a href="/customer/forgotpassword" class="self-end mb-5 text-xs hover:cursor-pointer">Forgot your password?</a>
        <button class="self-end rounded py-2 px-4 bg-neutral-800 text-neutral-100" type="submit"> Login </button>
    </Form>
</div>
