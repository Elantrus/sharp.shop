import type { CreateCustomer } from "$lib/models/customer/createCustomer";
import apiClient from "./api";

export class CustomerService{
    static async create(customerModel : CreateCustomer){
        return apiClient.post('/customer', customerModel);
    }

    static async get(){
        return apiClient.get('/customer');
    }
}