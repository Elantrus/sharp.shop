<script lang="ts">
	import Reviewcard from '$lib/components/ui/reviewcard.svelte';
	import Icon from '@iconify/svelte';
</script>

<div>
	<div class="flex flex-col md:flex-row justify-center items-stretch relative">
		<div class="relative w-full">
			<div class="-translate-x-10">
				<img src="/images/anya1_compress.png" width="100%" height="100%" alt="shirt" />
				<img class="absolute top-0 left-10" src="/images/anya1_compress.png" alt="shirt" />
				<img class="absolute top-0 left-20" src="/images/anya1_compress.png" alt="shirt" />
			</div>
			<!-- <Slideshow productImages={productImages} /> -->
		</div>
		<div class="min-w-1/2 flex flex-col justify-center">
			<h1 class="md:text-4xl">
				BECAUSE PEOPLE NEED TO KNOW: <span class="underline decoration-pink-500 decoration-4"
					>SPY X FAMILY</span
				>
				IS THE BEST<span class="blinking_cursor">|</span>
			</h1>
			<p class="text-xs mt-2 md:mt-8">
				Best quality Spy x Family t-shirts, so everyone needs to know the best anime out there. Spy
				x Family <span class="underline decoration-2 decoration-yellow-400"
					>fans loves our shirts.</span
				>
			</p>

			<div class="w-full mt-10">
				<button
					class="bg-neutral-800 text-white dark:bg-white dark:text-neutral-800 rounded w-full py-2"
					>BUY NOW</button
				>
			</div>
		</div>
	</div>
	<div class="mt-8 flex flex-col md:flex-row md:items-center gap-6 md:justify-center">
		<div class="md:flex gap-10">
			<div class="flex gap-2 text-sm mt-4">
				<div class="rounded bg-neutral-800 w-14 h-14 flex items-center justify-center">
					<div class="text-yellow-200 text-4xl">
						<Icon icon="pixelarticons:ac" />
					</div>
				</div>
				<div>
					<h4>100% Cotton</h4>
					<p class="text-xs text-neutral-400">Soft. Comfy. Breathable.</p>
				</div>
			</div>

			<div class="flex gap-2 text-sm mt-4">
				<div class="rounded bg-neutral-800 w-14 h-14 flex items-center justify-center">
					<div class="text-pink-200 text-4xl">
						<Icon icon="fa-brands:cotton-bureau" />
					</div>
				</div>
				<div>
					<h4>Superior Print</h4>
					<p class="text-xs text-neutral-400">High quality print method.</p>
				</div>
			</div>

			<div class="flex gap-2 text-sm mt-4">
				<div class="rounded bg-neutral-800 w-14 h-14 flex items-center justify-center">
					<div class="text-blue-200 text-4xl">
						<Icon icon="bxs:shield-alt-2" />
					</div>
				</div>
				<div>
					<h4>Durable</h4>
					<p class="text-xs text-neutral-400">Sewn using the best materials.</p>
				</div>
			</div>
		</div>
	</div>
	<div class="mt-10">
		<div class="mb-10 flex flex-col justify-center items-center gap-1">
			<h1 class="text-lg">Reviews</h1>
			<div class="rounded dark:p-2 dark:bg-neutral-800 inline">
				<span class="font-bold">5.0</span> ⭐⭐⭐⭐⭐
			</div>
			<p class="text-sm text-neutral-400">According to 129 customers.</p>
		</div>
		<Reviewcard />
		<Reviewcard />
		<Reviewcard />
		<Reviewcard />
		<Reviewcard />
	</div>
</div>

<style>
	.blinking_cursor {
		animation: 1.5s blink ease-in-out infinite;
	}

	@keyframes blink {
		from,
		to {
			opacity: 0;
		}
		50% {
			opacity: 1;
		}
	}
</style>
