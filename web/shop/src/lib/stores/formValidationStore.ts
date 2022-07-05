import { writable} from "svelte/store";

export const formValidationStore = _formValidationStore();


function _formValidationStore(){
    const {update, set, subscribe} = writable<boolean>(true);

    function validate (newValidationMessage: boolean) {
        update(currentValue => {
            return currentValue && newValidationMessage;
        })
    }

    return {
        subscribe,
        validate,
        update,
        reset: () => {
            set(true);
        }
    };
}