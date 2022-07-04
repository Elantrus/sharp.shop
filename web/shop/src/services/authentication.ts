import type { LoginModel } from "src/models/authentication/login";
import apiClient from "./api";

export class AuthenticationService{
    static async login(credentials : LoginModel){
        return apiClient.post('/authentication', credentials);
    }
}