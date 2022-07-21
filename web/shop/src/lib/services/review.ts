import type { ICreateReviewRequest } from "$lib/models/reviews/createReview";
import apiClient from "./api";

class ReviewService{
    async getReviews(){
        return apiClient.get('/review');
    }

    async createReview(request: ICreateReviewRequest){
        return apiClient.post('/review', request);
    }
}

export const reviewService : ReviewService = new ReviewService();