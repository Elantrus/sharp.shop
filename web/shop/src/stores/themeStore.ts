import { browser } from "$app/env";
import { get, writable, type Updater } from "svelte/store";


export const theme = _theme();


function _theme(){
    function updateTheme(selectedTheme : string){
        if(!browser) return;

        if(selectedTheme === 'dark'){
            document.documentElement.classList.add('dark');
        }
        else{
            document.documentElement.classList.remove('dark');
        }
    }

    const selectedTheme  = (browser ? localStorage.getItem('dark_theme') : 'light');

    updateTheme(selectedTheme as string);

    const {set, update, subscribe} = writable(selectedTheme);

    return {
        set: (newOption: string) => {
            if(!browser) return;

            localStorage.setItem('dark_theme', newOption as string);

            set(newOption);
        },
        get: get,
        update: ( newOption : Updater<string | null>) => {
            if(!browser) return;

            let selectedOption = newOption.call(null, get(theme) as string);

            localStorage.setItem('dark_theme',  selectedOption as string);

            updateTheme(selectedOption as string);

            update(newOption);
        },
        subscribe
    }
}