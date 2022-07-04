import type { LoginModel } from "src/models/customer/login";
import apiClient from "./api";

export class AuthenticationService{
    static async login(credentials : LoginModel){
        return apiClient.post('/authentication', credentials);
    }
}