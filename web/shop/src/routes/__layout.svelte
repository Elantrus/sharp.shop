<script lang="ts">
    import "../app.css";
    import Icon from '@iconify/svelte';
    import {slide} from 'svelte/transition'
    import { browser } from "$app/env";

    //Stores
    import {theme} from '../stores/themeStore';
    import {customer} from '../stores/customerStore'

    //Toast
    import Toast from "../components/notification/toast.svelte";
    
    import { goto } from "$app/navigation";

    let showNavbar = false;

    
    function toggleNavbar(){
        showNavbar = !showNavbar;
    }

    function toggleDarkMode(){
        theme.update(current => {
                return current === 'dark' ? 'light' : 'dark';
            }
        );
    }

    function customerPage(){
        if($customer){
            goto('/customer');
        }
        else{
            goto('/auth/login');
        }
    }



</script>

<template>
    <header class="flex justify-between md:items-center py-6 px-10 md:w-10/12 2xl:w-5/12 w-full">
        <div>
            <img src="/images/logo.png" alt="logo">
        </div>
        <div>
            <nav class="flex flex-col justify-between items-end">

                <div>
                    <button class="md:hidden" on:click={toggleDarkMode}>
                        <Icon icon="carbon:light-filled" />
                    </button>
                    <button class="md:hidden" on:click={customerPage}>
                        <Icon icon="bxs:user" />
                    </button>
                    <button class="md:hidden" on:click={toggleNavbar}>
                        <Icon icon="dashicons:menu-alt3" />
                    </button>
                </div>
                
                {#if showNavbar}
                    <ul class="md:hidden" transition:slide>
                        <li class=" hover:bg-neutral-200 dark:hover:bg-neutral-800 rounded hover:cursor-pointer"><a class="block w-full h-full py-1 px-2" href="/">Home</a></li>
                        <li class=" hover:bg-neutral-200 dark:hover:bg-neutral-800 rounded hover:cursor-pointer"><a class="block w-full h-full py-1 px-2" href="/contact">Contact</a></li>
                        <li class=" hover:bg-neutral-200 dark:hover:bg-neutral-800 rounded hover:cursor-pointer"><a class="block w-full h-full py-1 px-2" href="/tracking">Tracking</a></li>
                    </ul>
                {/if}
                
                <ul class="hidden md:flex gap-4 items-center">
                    <li class="rounded hover:bg-neutral-200 dark:hover:bg-neutral-800 hover:cursor-pointer"><a class="block w-full h-full py-1 px-2" href="/">Home</a></li>
                    <li class="rounded hover:bg-neutral-200 dark:hover:bg-neutral-800 hover:cursor-pointer"><a class="block w-full h-full py-1 px-2" href="/contact">Contact</a></li>
                    <li class="rounded hover:bg-neutral-200 dark:hover:bg-neutral-800 hover:cursor-pointer"><a class="block w-full h-full py-1 px-2" href="/tracking">Tracking</a></li>
                    <li class="hover:cursor-pointer text-2xl" on:click={toggleDarkMode}>
                        <Icon icon="carbon:light-filled" />
                    </li>
                    <li on:click={customerPage} class="text-xl hover:cursor-pointer">
                        <Icon icon="bxs:user" />
                    </li>
                </ul>
            </nav>
        </div>
    </header>
</template>

<main class="px-10 py-16 mx-auto md:w-10/12 2xl:w-5/12 h-full w-full">
    <slot />
</main>

<footer class="py-20 px-6 text-center text-sm">
    <p>
        Made with love by <strong>lazaro@sharpmeta.xyz</strong>
    </p>
</footer>

<Toast />

