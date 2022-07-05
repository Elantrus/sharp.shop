<script lang="ts">
	import Slideshow from "$lib/components/ui/slideshow.svelte";

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

<div class="flex flex-col md:flex-row justify-center gap-4">
	<div>
		<Slideshow productImages={productImages} />
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

		<div class="flex flex-col gap-4">
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
			<div class="md:self-end">
				<button class="w-full rounded bg-neutral-800 text-neutral-100 py-2 px-4 md:w-36"> Buy Now</button>
			</div>
		</div>
	</div>
</div>
