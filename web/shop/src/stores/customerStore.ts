import { browser } from "$app/env";
import type {CustomerModel} from "src/models/customer";
import { writable, get, type Updater } from "svelte/store";

export const customer = _customer();


function _customer(){
    const {set, update, subscribe} = writable<CustomerModel>();

    if(browser){
        let customerFromStorage : CustomerModel = JSON.parse(localStorage.getItem('customer') as string);

        set(customerFromStorage);
    }

    return {
        set: (newCustomer : CustomerModel) => {
            if(!browser) return;

            localStorage.set('customer', JSON.stringify(newCustomer));

            set(newCustomer);
        },
        update: ( customerUpdater : Updater<CustomerModel>) => {
            if(!browser) return;

            let updatedCustomer = customerUpdater.call(null, get(customer) as CustomerModel);

            localStorage.setItem('customer',  JSON.stringify(updatedCustomer));

            update(customerUpdater);
        },
        subscribe,
        get: get
    };
}