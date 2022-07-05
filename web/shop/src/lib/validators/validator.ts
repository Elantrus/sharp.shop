import { writable } from "svelte/store";
import { formValidationStore } from "$lib/stores/formValidationStore";

export interface IValidationMessage {
    message: string,
    valid: boolean
}

export function inputValidator(validators: Function[]): any[] {
    const { subscribe, set } = writable<IValidationMessage>({ message: '', valid: true });

    function nodeHandler(node: any) {

        const formNode = node.parentNode.parentNode;

        const handleBlur = (event: any) => {

            if(validators.length === 0) {
                set(
                    { message: '', valid: true }
                );

                return;
            }

            validators.forEach(handler => {
                const handleResult: IValidationMessage = handler(node.value);

                set(
                    { message: handleResult.message, valid: handleResult.valid }
                );
            });
        }

        const handleSubmit = (event: any) => {
            if(validators.length === 0) {
                set(
                    { message: '', valid: true }
                );

                return;
            }

            validators.forEach(handler => {
                const handleResult: IValidationMessage = handler(node.value);

                set(
                    { message: handleResult.message, valid: handleResult.valid }
                );

                formValidationStore.validate(handleResult.valid);
            });
        }
        node.addEventListener('blur', handleBlur)
        formNode.addEventListener('submit', handleSubmit)

        return {
            destroy() {
                node.removeEventListener('blur', handleBlur);
                formNode.removeEventListener('submit', handleSubmit);
            }
        }
    }

    return [nodeHandler, { subscribe }];
}
