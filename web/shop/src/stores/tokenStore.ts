import { browser } from "$app/env";
import type {TokenModel} from "src/models/token";
import { writable, get, type Updater } from "svelte/store";

export const token = _token();

const TOKEN_KEY = 'token';


function _token(){
    const {set, update, subscribe} = writable<TokenModel>();

    if(browser){
        let tokenFromStorage : TokenModel = localStorage.get(TOKEN_KEY);

        set(tokenFromStorage);
    }

    return {
        set: (newCustomer : TokenModel) => {
            if(!browser) return;

            localStorage.set(TOKEN_KEY, JSON.stringify(newCustomer));

            set(newCustomer);
        },
        update: ( customerUpdater : Updater<TokenModel>) => {
            if(!browser) return;

            let updatedCustomer = customerUpdater.call(null, get(token) as TokenModel);

            localStorage.setItem(TOKEN_KEY, JSON.stringify(updatedCustomer));

            update(customerUpdater);
        },
        subscribe,
        get: get
    };
}