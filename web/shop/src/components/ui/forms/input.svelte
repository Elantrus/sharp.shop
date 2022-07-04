<script lang="ts">
    export let type: string;
    export let value: any;
    export let isValid: boolean;

import Icon from '@iconify/svelte';
    import {emailValidator} from '../../../validators/email';
    import {passwordValidator} from '../../../validators/password';

    const icons : {[key: string]: string} = {
        "password": "ri:lock-password-fill",
        "email": "ic:baseline-email"
    }

    let errors : string | null = null;

    function handleChange(e : any){
        value = e.target.value;
        
        switch(type){
            case 'email':
                errors = emailValidator(value);
                break;
            case 'password':
                errors = passwordValidator(value);
                break;
        }

        if(errors) isValid = false;
        else isValid = true;

    }

</script>

<div class="flex flex-col gap-1">
    <label class="text-xs" for="email"> <slot /> </label>
    <input {type} on:blur={handleChange} on:change={handleChange} class={`${icons[type] ? 'pl-9' : ''} shadow text-neutral-700 text-sm py-2 px-2 rounded border-none focus:outline-none focus:outline-neutral-600" name="email`} >
    <span class="relative pl-2 -top-8 h-px text-xl text-neutral-700 w-0">
        <Icon icon={`${icons[type]}`} />
    </span>
    {#if errors}
        <span class="text-xs self-end text-red-500">{errors}</span>
    {/if}
</div>
