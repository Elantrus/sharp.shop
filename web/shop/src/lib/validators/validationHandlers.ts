import type { IValidationMessage } from "./validator";

function handleEmail(email: string) : IValidationMessage{

    if(email && email.match(
        /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
      ))
      return {valid: true, message: ''};

    return {valid: false, message: 'Provided e-mail is invalid.'};
}

function handlePassword(password: string) : IValidationMessage{

    if(password) return {valid: true, message: ''};

    return {valid: false, message: 'Provided password is too short.'};
}

function handleRequired(input: string) : IValidationMessage{

    if(input && input.length > 0)
      return {valid: true, message: ''};

    return {valid: false, message: 'Field is required.'};
}




export const emailValidator = (email : string) => handleEmail(email);

export const passwordValidator = (password : string) => handlePassword(password);

export const requiredValidator = (input : string) => handleRequired(input);
