import type { CreateCustomer } from "src/models/customer/register";
import apiClient from "./api";

export class CustomerService{
    static async create(customerModel : CreateCustomer){
        return apiClient.post('/customer', customerModel);
    }
}