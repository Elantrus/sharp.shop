<script lang="ts">
	export let type: string;
	export let value: any;
    export let name: string;
    export let validators: Function[] = [];

	import Icon from '@iconify/svelte';
	import { inputValidator } from '$lib/validators/validator';
	
    let [handler, results] = inputValidator(validators);

	const icons: { [key: string]: string } = {
		password: 'ri:lock-password-fill',
		email: 'ic:baseline-email'
	};

	function handleBlur(e : any){
		value = e.target.value;
	}

</script>

<div class="flex flex-col gap-1">
	<label class="text-xs" for={name}> <slot /> </label>
	<input
		{type}
		{name}
        use:handler
        value={value}
		on:blur={handleBlur}
		class={`${
			icons[type] ? 'pl-9' : ''
		} shadow text-neutral-700 text-sm py-2 px-2 rounded border-none focus:outline-none focus:outline-neutral-600" name="email`}
	/>
	<span class="relative pl-2 -top-8 h-px text-xl text-neutral-700 w-0">
		<Icon icon={`${icons[type]}`} />
	</span>
    
	{#if !$results.valid}
		<span class="text-xs self-end text-red-500">{$results.message}</span>
	{/if}
</div>
