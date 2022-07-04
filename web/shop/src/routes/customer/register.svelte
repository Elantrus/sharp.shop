<script lang="ts">
    import Input from '../../components/ui/forms/input.svelte'
    import {CustomerService} from '../../services/customer'
    import {notifications} from '../../stores/notificationStore';
    import { AuthenticationService } from '../../services/authentication';
    import { credentials } from '../../stores/credentialsStore';

    //Models
    import type { CreateCustomer} from '../../models/customer/register'
    import type {AuthenticationResult} from '../../models/authentication/credentials'
    import type {CustomerAuthentication} from '../../models/customer/login'
    
    import {page} from "$app/stores";
    import { goto } from '$app/navigation';
    import {visitor} from '../../stores/visitorStore'

    export let query : URLSearchParams = $page.url.searchParams;
    
    let createCustomerModel : CreateCustomer = {
       email : '',
       name: '',
       surName: '',
       password: ''
    };

    let formValidation : any = {
        "email": {
            field: createCustomerModel.email,
            valid: false
        },
        "name": {
            field: createCustomerModel.name,
            valid: false
        },
        "surName": {
            field: createCustomerModel.name,
            valid: false
        },
        "password": {
            field: createCustomerModel.name,
            valid: false
        }
    };

    async function register(){
        CustomerService.create(createCustomerModel).then(response => {
            const loginCredentials : CustomerAuthentication = {
                email: createCustomerModel.email,
                password: createCustomerModel.password,
                deviceId: $visitor
            };

            AuthenticationService.login(loginCredentials).then(authResponse => {
                const data : AuthenticationResult = authResponse.data;
                credentials.set(data);

                let callBack = query.get("callback");

                goto(callBack ? callBack : "/");
            }).catch(error => notifications.danger(error, 300))

        }).catch(error => notifications.danger(error, 3000));
    }
 
</script>

<div class="flex flex-col gap-10 items-center min-h-full md:w-96 self-center">
    <div class="flex flex-col items-center">
        <h1 class="font-semibold text-xl">Creating a new account</h1>
        <p class="text-sm text-neutral-500 text-center">Provide some informations to create your new account. Already have an account? <a class="underline" href="/auth/register">Proceed to login</a></p>
    </div>
    <form on:submit|preventDefault={register} class="flex flex-col gap-2 w-full">
        
        <Input bind:value={createCustomerModel.name} type="text" bind:isValid={formValidation["name"].valid}>Name</Input>

        <Input bind:value={createCustomerModel.surName} type="text" bind:isValid={formValidation["surName"].valid}>Surname</Input>

        <Input bind:value={createCustomerModel.email} type="email" bind:isValid={formValidation["email"].valid}>E-mail</Input>

        <Input bind:value={createCustomerModel.password} type="password" bind:isValid={formValidation["password"].valid}>Password</Input>

        <button class="self-end rounded py-2 px-4 bg-neutral-800 text-neutral-100" type="submit"> Register </button>
    </form>
</div>
