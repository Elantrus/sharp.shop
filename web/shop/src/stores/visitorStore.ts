
import { browser } from "$app/env";
import type {CredentialsModel} from "../models/authentication/authenticationResult";
import { writable, get, type Updater } from "svelte/store";

export const visitor = _visitor();


function _visitor(){
    const visitor_key = 'visitor_id';

    const {set, update, subscribe} = writable<string>();

    if(browser){
        let visitorIdFromStorage : string = localStorage.getItem(visitor_key) as string;

        if(!visitorIdFromStorage){
            visitorIdFromStorage = broofa();
        }

        set(visitorIdFromStorage);
    }

    return {
        set: (newId : string) => {
            if(!browser) return;

            localStorage.set(visitor_key, JSON.stringify(newId));

            set(newId);
        },
        update: ( customerUpdater : Updater<string>) => {
            if(!browser) return;

            let updatedVisitorId = customerUpdater.call(null, get(visitor) as string);

            localStorage.setItem(visitor_key, JSON.stringify(updatedVisitorId));

            update(customerUpdater);
        },
        subscribe,
        get: get
    };
}

//Generates random UUID using broofa method
function broofa() : string {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
        var r = Math.random()*16|0, v = c == 'x' ? r : (r&0x3|0x8);
        return v.toString(16);
    });
}