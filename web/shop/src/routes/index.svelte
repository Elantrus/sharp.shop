<script lang="ts">
	import { onDestroy } from 'svelte';
	import { fly, slide } from 'svelte/transition';
	import { sineInOut } from 'svelte/easing';
	import Icon from '@iconify/svelte';

	const productImages: { value: string; id: number }[] = [
		{
			value: '/images/product1.jpg',
			id: 0
		},
		{
			value: '/images/product2.jpg',
			id: 1
		},
		{
			value: '/images/product3.jpg',
			id: 2
		},
		{
			value: '/images/product4.jpg',
			id: 3
		},
		{
			value: '/images/product5.jpg',
			id: 4
		}
	];

	let currentImageIndex = 0;

	const carrousel = setInterval(() => {
		if (currentImageIndex >= productImages.length) currentImageIndex = 0;
		else currentImageIndex++;
	}, 6000);

	onDestroy(() => clearInterval(carrousel));
</script>

<div class="flex justify-center gap-4">
	<div>
		<div>
            <div class="h-48">
                {#each productImages as image}
                    {#if currentImageIndex === image.id}
                        <img
                            class="w-full"
                            out:fly={{ duration: 300, x: 100 }}
                            in:fly={{ delay: 200, duration: 300, x: -100 }}
                            src={image.value}
                            alt=""
                        />
                    {/if}
			    {/each}
            </div>
			
			<div class="flex justify-center pt-4">
				<Icon icon="ic:round-navigate-before" />
				<Icon icon="ic:round-navigate-next" />
			</div>
		</div>
		<div />
	</div>
	<div class="flex flex-col gap-6">
		<div>
			<h4 class="text-lg">T-Shirt Anya</h4>
			<p class="text-sm text-neutral-400">
				Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam, dolores consequuntur
				temporibus animi suscipit obcaecati sint nisi provident aliquid voluptatum architecto natus
				sapiente ipsum corrupti minus quas distinctio aut ea?
			</p>
		</div>

		<div class="flex flex-col ">
			<div class="flex justify-between items-center">
				<div class="flex gap-2 items-center">
					<h5 class="line-through text-neutral-400">$99</h5>
					<h3 class="text-2xl">$21</h3>
				</div>
				<div>
					<div class="text-xs text-neutral-500">21 reviews</div>
					<div>⭐⭐⭐⭐⭐</div>
				</div>
			</div>
			<div>
				<button> Buy Now</button>
			</div>
		</div>
	</div>
</div>
