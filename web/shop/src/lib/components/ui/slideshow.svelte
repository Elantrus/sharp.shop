<script lang="ts">
    import { onDestroy } from 'svelte';
    import { fly, slide } from 'svelte/transition';
    import { cubicOut } from 'svelte/easing'
    import Icon from '@iconify/svelte';

    export let productImages : { value: string; id: number }[] = [];

    const transition_args = {
		duration: 200,
	}

	function nextImage(){
		if (currentImageIndex === productImages.length) currentImageIndex = 1;
		else currentImageIndex++;
	}

	function previousImage(){
		if (currentImageIndex === 1) currentImageIndex = productImages.length - 1;
		else currentImageIndex--;
	}

    let currentImageIndex = 1;

	const carrousel = setInterval(() => {
		nextImage();
	}, 6000);
    
    onDestroy(() => clearInterval(carrousel));
</script>

<div class="flex flex-col justify-center items-center">
    <div class="rounded min-w-84 max-w-xs h-56 md:w-48 md:h-48 overflow-clip shadow">
        {#each productImages as image}
            {#if currentImageIndex === image.id}
                <img
                    class="slide "
                    in:slide={transition_args}
                    out:slide={transition_args}
                    src={image.value}
                    alt=""
                />
            {/if}
        {/each}
    </div>
    <div class="flex justify-center text-2xl gap-10">
        <div class="hover:cursor-pointer" on:click={previousImage}>
            <Icon icon="ic:round-navigate-before" />
        </div>
        <div class="hover:cursor-pointer" on:click={nextImage}>
            <Icon icon="ic:round-navigate-next" />
        </div>
    </div>
</div>

<style>
	.slide {
		flex: 1 0 auto;
		width: 100%;
		height: 100%;
		background: red;
	    align-items: center;
		justify-content: center;
		display: flex;
		text-align: center;
		font-weight: bold;
		font-size: 2rem;
		color: white;
	}
</style>