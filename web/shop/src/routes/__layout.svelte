<script>
    import "../app.css";
    import Icon from '@iconify/svelte';
    import {slide} from 'svelte/transition'
    import { browser } from "$app/env";

    //Stores
    import {theme} from '../stores/themeStore';
    import {customer} from '../stores/customerStore'

import { goto } from "$app/navigation";

    let showNavbar = false;

    theme.subscribe((value) => {
        if(browser){
            if(value === 'dark'){
                document.documentElement.classList.add('dark');
            }
            else{
                document.documentElement.classList.remove('dark');
            }
        }
    })
    
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
        if(!$customer){
            goto('/login');
        }

        goto('/customer');
    }
</script>

<template>
    <header class="flex justify-between md:items-center py-6 px-10 mx-auto md:w-10/12 2xl:w-5/12 ">
        <div>
            <img src="/images/logo.png" alt="logo">
        </div>
        <div>
            <nav class="flex flex-col justify-between items-end">

                <div>
                    <button class="md:hidden" on:click={toggleNavbar}>
                        <Icon icon="dashicons:menu-alt3" />
                    </button>
                    <button class="md:hidden" on:click={toggleDarkMode}>
                        <Icon icon="carbon:light-filled" />
                    </button>
                    <button class="md:hidden" on:click={customerPage}>
                        <Icon icon="bxs:user" />
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
                    <li class="rounded py-2 px-3 hover:bg-neutral-200 dark:hover:bg-neutral-800 hover:cursor-pointer">Home</li>
                    <li class="rounded py-2 px-3 hover:bg-neutral-200 dark:hover:bg-neutral-800 hover:cursor-pointer">Contact</li>
                    <li class="rounded py-2 px-3 hover:bg-neutral-200 dark:hover:bg-neutral-800 hover:cursor-pointer">Tracking</li>
                    <li class="hover:cursor-pointer text-2xl" on:click={toggleDarkMode}>
                        <Icon icon="carbon:light-filled" />
                    </li>
                </ul>
            </nav>
        </div>
    </header>
</template>

<main>
    <slot />
</main>

