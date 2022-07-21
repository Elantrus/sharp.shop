<script lang="ts">
    export let username : string;
    export let score : number;
    export let description : string;
    export let title : string;
</script>

<div class="mt-2 flex gap-4 border-2 border-neutral-300 dark:border-neutral-700 rounded p-2">
    <div>
        <div class="h-12 w-12 rounded-full bg-neutral-300 dark:bg-neutral-800"></div>
    </div>
    <div class="text-xs"> 
        <h4 class="font-medium">{username} - {title}</h4>
        <p>
            {#each Array(score) as i}
                ⭐
            {/each}
        </p>
        <p class="mt-2 text-neutral-700 dark:text-neutral-400">
            {description}
        </p>
    </div>
</div>