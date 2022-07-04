import { get, writable, derived } from "svelte/store"
import type {Updater} from "svelte/store"

const TIMEOUT = 3000

export const notifications = createNotificationStore()

interface IMessage{
    id: string; 
    type: string; 
    message: any; 
    timeout: any;
}

function createNotificationStore () {
    const {subscribe, update} = writable<IMessage[]>([])

    function send (message : any, type = "default", timeout : any) {
        update(state => {
            return [...state, { id: id(), type, message, timeout }]
        });
        const timer = setTimeout(() => {
            update(state => {
                state.shift();
                return state;
            })
        }, timeout)

        return () => {
            clearTimeout(timer)
        };
    }

    return {
        subscribe,
        send,
		default: (msg : string, timeout: number) => send(msg, "default", timeout),
        danger: (msg : string, timeout: number) => send(msg, "danger", timeout),
        warning: (msg : string, timeout: number) => send(msg, "warning", timeout),
        info: (msg : string, timeout: number) => send(msg, "info", timeout),
        success: (msg : string, timeout: number) => send(msg, "success", timeout),
        get: get,
        update
    }
}

function id() {
    return '_' + Math.random().toString(36).substr(2, 9);
};
