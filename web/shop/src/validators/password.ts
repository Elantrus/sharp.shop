export const passwordValidator = (password : string) => _passwordValidator(password);


function _passwordValidator(password: string) : string | null{

    if(password) return '';

    return 'Provided password is too short.';
}