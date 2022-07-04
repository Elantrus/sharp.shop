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
    if(config.headers)
      config.headers["Authorization"] = `Bearer ${credentials.get()}`;
    
    return config;
  },
  error => {
    return Promise.reject(error);
  }
);
export default apiClient;