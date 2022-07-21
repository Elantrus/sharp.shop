import apiClient from "./api";

class ProductService{
    async getLatestProduct(){
        return apiClient.get('/product');
    }
}

export const productService : ProductService = new ProductService();