function isPasswordValid(pass) {
    let valid = true;

    if (pass.length < 6 || pass.length > 10) {
        valid = false;
        console.log("Password must be between 6 and 10 characters");
    }

    if (!pass.match(/^[A-Za-z0-9]+$/)) {
        valid = false;
        console.log("Password must consist only of letters and digits");
    }

    if (!pass.match(/\d/g) || pass.match(/\d/g).length < 2) {
        valid = false;
        console.log("Password must have at least 2 digits");
    }

    if (valid) {
        console.log("Password is valid");
    }
}