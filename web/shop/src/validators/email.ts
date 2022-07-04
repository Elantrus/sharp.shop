export const emailValidator = (email : string) => _emailValidator(email);


function _emailValidator(email: string) : string | null{

    if(email.match(
        /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
      ))
      return null;

    return 'Provided e-mail is invalid.';
}