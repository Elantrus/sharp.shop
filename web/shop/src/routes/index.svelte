<script lang="ts">
	import Slideshow from "$lib/components/ui/slideshow.svelte";
import Icon from "@iconify/svelte";

	const productImages: { value: string; id: number }[] = [
		{
			value: '/images/product1.jpg',
			id: 1
		},
		{
			value: '/images/product2.jpg',
			id: 2
		},
		{
			value: '/images/product3.jpg',
			id: 3
		},
		{
			value: '/images/product4.jpg',
			id: 4
		},
		{
			value: '/images/product5.jpg',
			id: 5
		}
	];
</script>

<div>
	<div class="flex flex-col md:flex-row justify-center items-center relative">
		<div class="relative w-full">
			<div>
				<img class="absolute top-0 left-0" src="/images/anya1_compress.png" alt="shirt"/>
				<img class="rotate-12" src="/images/anya1_compress.png" alt="shirt"/>
			</div>
			<!-- <Slideshow productImages={productImages} /> -->
		</div>
		<div class="min-w-1/2">
			<h1 class="md:text-4xl">
				BECAUSE PEOPLE NEED TO KNOW: <span class="underline decoration-pink-500 decoration-4">SPY X FAMILY</span> IS THE BEST
			</h1>
			<p class="text-xs mt-2 md:mt-8">
				Best quality Spy x Family t-shirts, so everyone needs to know the <span class="underline decoration-yellow-500 decoration-2">best anime</span> out there!
			</p>
			
		</div>
	</div>
	<div class="mt-8 flex flex-col md:flex-row md:justify-start md:items-center gap-6">
		<div class="md:flex">
			<div class="flex gap-2 text-sm mt-4">
				<div class="rounded bg-neutral-800 w-14 h-14 flex items-center justify-center">
					<div class="text-yellow-200 text-4xl">
						<Icon icon="pixelarticons:ac"></Icon>
					</div>
				</div>
				<div>
					<h4>
						100% Cotton
					</h4>
					<p class="text-xs text-neutral-400">Soft. Comfy. Breathable.</p>
				</div>
			</div>

			<div class="flex gap-2 text-sm mt-4">
				<div class="rounded bg-neutral-800 w-14 h-14 flex items-center justify-center">
					<div class="text-pink-200 text-4xl">
						<Icon icon="fa-brands:cotton-bureau"></Icon>
					</div>
				</div>
				<div>
					<h4>
						Superior Print
					</h4>
					<p class="text-xs text-neutral-400">High quality print method.</p>
				</div>
			</div>
		</div>
		<div class="w-full md:w-3/5 mt-2">
			<button class="bg-neutral-800 text-white dark:bg-white dark:text-neutral-800 rounded w-full py-2">BUY NOW</button>
		</div>
		
	</div>
</div>

