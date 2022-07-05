<script lang="ts">
    import {formValidationStore} from '$lib/stores/formValidationStore'
    import {notifications} from '$lib/stores/notificationStore'

    export let submitHandler : Function;

    function checkSubmit(){
        if(!$formValidationStore){
            notifications.danger('Fill the forms properly.', 3000);
        }else{
            submitHandler();
        }

        formValidationStore.reset();
    }

</script>
<form on:submit|preventDefault={checkSubmit} class="flex flex-col gap-2 w-full">
	<slot />

</form>