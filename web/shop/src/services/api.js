import axios from "axios";

const apiClient = axios.create({
    baseURL: 'http://localhost:5260/api'
});

apiClient.interceptors.response.use(response => {
        return response;
    }, function (error) {
    return Promise.reject(error.response?.data?.message);
  });

export default apiClient;