<script lang="ts">
    import { flip } from "svelte/animate";
import { get } from "svelte/store";
    import { fly } from "svelte/transition";
    import { notifications } from "../../stores/notificationStore";

    export let themes : any = {
        danger: "bg-red-500",
        success: "bg-green-500",
        warning: "bg-orange-500",
        info: "bg-blue-500",
        default: "bg-neutral-800",
    };
</script>

<div class="notifications">

    {#each $notifications as {id, type, message} (id)}
        <div
            animate:flip
            class={`toast ${themes[type]}`}
            transition:fly={{ y: 30 }}
        >
            <div class="content bg-neu">{message}</div>
        </div>
    {/each}
</div>

<style>
    .notifications {
        position: fixed;
        top: 10px;
        left: 0;
        right: 0;
        margin: 0 auto;
        padding: 0;
        z-index: 9999;
        display: flex;
        flex-direction: column;
        justify-content: flex-start;
        align-items: center;
        pointer-events: none;
    }

    .toast {
        flex: 0 0 auto;
        margin-bottom: 10px;
    }

    .content {
        padding: 10px;
        display: block;
        color: white;
        font-weight: 500;
    }
</style>