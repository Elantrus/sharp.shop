import type { CustomerAuthentication } from "$lib/models/customer/customerAuthentication";
import apiClient from "./api";

export class AuthenticationService{
    static async login(credentials : CustomerAuthentication){
        return apiClient.post('/authentication', credentials);
    }
}