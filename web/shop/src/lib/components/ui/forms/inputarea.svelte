<script lang="ts">
	import {slide} from 'svelte/transition'
	export let value: any;
    export let name: string;
    export let validators: Function[] = [];
    export let maxlength: number;
    export let rows: number;

	import Icon from '@iconify/svelte';
	import { inputValidator } from '$lib/validators/validator';
	
    let [handler, results] = inputValidator(validators);

	const icons: { [key: string]: string } = {
		password: 'ri:lock-password-fill',
		email: 'ic:baseline-email'
	};

	function handleChange(e : any){
		value = e.target.value;
	}

</script>

<div class="flex flex-col gap-1">
	<label class="text-xs" for={name}> <slot /> </label>
	<textarea
		{name}
        use:handler
        maxlength={maxlength}
        rows={rows}
        value={value}
		on:change={handleChange}
		class={`shadow text-neutral-700 text-sm py-2 px-2 rounded border-none focus:outline-none focus:outline-neutral-600" name="email`}
	/>
    
	{#if !$results.valid}
		<span transition:slide class="text-xs self-end text-red-500">{$results.message}</span>
	{/if}
</div>
