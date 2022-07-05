import { browser } from "$app/env";
import type {AuthenticationResult} from "$lib/models/authentication/authenticationResult";
import { writable, get, type Updater } from "svelte/store";

export const credentials = _credentials();


function _credentials(){
    const token_key = 'credentials';
    const {set, update, subscribe} = writable<AuthenticationResult>();

    if(browser){
        let tokenFromStorage : AuthenticationResult = JSON.parse(localStorage.getItem(token_key) as string);

        set(tokenFromStorage);
    }

    return {
        set: (newCustomer : AuthenticationResult) => {
            if(!browser) return;

            localStorage.setItem(token_key, JSON.stringify(newCustomer));

            set(newCustomer);
        },
        update: ( customerUpdater : Updater<AuthenticationResult>) => {
            if(!browser) return;

            let updatedCustomer = customerUpdater.call(null, get(credentials) as AuthenticationResult);

            localStorage.setItem(token_key, JSON.stringify(updatedCustomer));

            update(customerUpdater);
        },
        subscribe,
        get: () => get(credentials)
    };
}