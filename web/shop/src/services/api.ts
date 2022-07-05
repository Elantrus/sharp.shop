import axios from "axios";
import { credentials } from "../stores/credentialsStore";

const apiClient = axios.create({
    baseURL: 'http://localhost:5260/api'
});

apiClient.interceptors.response.use(response => 
  {
    return response;
  }, error => {
    return Promise.reject(error.response?.data?.message);
  }
);


apiClient.interceptors.request.use(config => 
  {
    let storedCredentials = credentials.get();
    if(config.headers && storedCredentials?.token)
      config.headers["Authorization"] = `Bearer ${storedCredentials.token}`;
    
    return config;
  },
  error => {
    return Promise.reject(error);
  }
);
export default apiClient;