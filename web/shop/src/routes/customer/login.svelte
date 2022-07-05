<script lang="ts">
    import { page } from '$app/stores'
    
    import type { CustomerAuthentication } from "../../models/customer/customerAuthentication";
    import { AuthenticationService } from "../../services/authentication";
    import { onMount } from "svelte";

    //stores
    import { visitor } from "../../stores/visitorStore";
    import {notifications } from "../../stores/notificationStore"
    import {credentials} from "../../stores/credentialsStore"
    import type { AuthenticationResult } from "../../models/authentication/authenticationResult";

    import Input from "../../components/ui/forms/input.svelte";
    import { goto } from "$app/navigation";

    export let query : URLSearchParams = $page.url.searchParams;

    let loginData : CustomerAuthentication = {
            email: "",
            password: "",
            deviceId: $visitor
    };

    let formValidation : any = {
        "email": {
            field: loginData.email,
            valid: false
        },
        "password": {
            field: loginData.password,
            valid: false
        }
    };
 

    async function login(){
        if(!Object.keys(formValidation).every((x:any) => formValidation[x].valid)){
            return;
        }

        await AuthenticationService.login(loginData).then((result)  => {
            const data : AuthenticationResult = result.data;
            credentials.set(data);

            let callBack = query.get("callback");

            goto(callBack ? callBack : "/");
        }).catch(error => notifications.danger(error, 3000));
    }

</script>

<div class="flex flex-col gap-10 items-center min-h-full md:w-96 self-center">
    <div class="flex flex-col items-center">
        <h1 class="font-semibold text-xl">Welcome!</h1>
        <p class="text-sm text-neutral-500 text-center">Sign-in using your credentials. Are you new here? <a class="underline" href="/customer/register">Create a new account</a></p>
    </div>
    <form on:submit|preventDefault={login} class="flex flex-col gap-2 w-full">
        <Input bind:value={loginData.email} type="email" bind:isValid={formValidation["email"].valid}>E-mail</Input>
        <Input bind:value={loginData.password} type="password" bind:isValid={formValidation["password"].valid}>Password</Input>
        <a href="/customer/forgotpassword" class="self-end mb-5 text-xs hover:cursor-pointer">Forgot your password?</a>
        <button class="self-end rounded py-2 px-4 bg-neutral-800 text-neutral-100" type="submit"> Login </button>
    </form>
</div>
