<script lang="ts">
import type { ICreateReviewRequest } from "$lib/models/reviews/createReview";
import { reviewService } from "$lib/services/review";
import { notifications } from "$lib/stores/notificationStore";
import { requiredValidator } from "$lib/validators/validationHandlers";
    import Form from "./forms/form.svelte";
import Input from "./forms/input.svelte";
import Inputarea from "./forms/inputarea.svelte";
    export let productId : number;

    let createReviewRequest : ICreateReviewRequest = {
        description: '',
        productId: productId,
        score: 0,
        title: ''
    }

    function handleReviewSubmit(){
        reviewService.createReview(createReviewRequest).catch(error => notifications.danger(error, 3000));
    }
</script>

<Form submitHandler={handleReviewSubmit}>
    <Input type="text" name="title" bind:value={createReviewRequest.title} validators={[requiredValidator]}>Title</Input>
    <Inputarea maxlength={200} rows={2} name="description" validators={[requiredValidator]} bind:value={createReviewRequest.description}>Your review</Inputarea>
    <button class="bg-neutral-800 mt-2 p-1 rounded" type="submit">Send review</button>
</Form>