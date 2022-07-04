import { browser } from "$app/env";
import type {CredentialsModel} from "../models/authentication/credentials";
import { writable, get, type Updater } from "svelte/store";

export const credentials = _credentials();


function _credentials(){
    const token_key = 'credentials';
    const {set, update, subscribe} = writable<CredentialsModel>();

    if(browser){
        let tokenFromStorage : CredentialsModel = JSON.parse(localStorage.getItem(token_key) as string);

        set(tokenFromStorage);
    }

    return {
        set: (newCustomer : CredentialsModel) => {
            if(!browser) return;

            localStorage.setItem(token_key, JSON.stringify(newCustomer));

            set(newCustomer);
        },
        update: ( customerUpdater : Updater<CredentialsModel>) => {
            if(!browser) return;

            let updatedCustomer = customerUpdater.call(null, get(credentials) as CredentialsModel);

            localStorage.setItem(token_key, JSON.stringify(updatedCustomer));

            update(customerUpdater);
        },
        subscribe,
        get: get
    };
}