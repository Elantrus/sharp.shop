import { browser } from "$app/env";
import type {GetCustomer} from "../models/customer/getCustomer";
import { writable } from "svelte/store";

export const customer = writable<GetCustomer>();