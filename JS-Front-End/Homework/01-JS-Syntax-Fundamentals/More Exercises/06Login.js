function login([username, ...attempts]) {
    const password = Array.from(username).reverse().join("");

    for (let i = 0; i < attempts.length; i++) {
        if (attempts[i] === password) {
            console.log(`User ${username} logged in.`);
            break;
        }
        
        if (i === 3) {
            console.log(`User ${username} blocked!`);
            break;
        }

        console.log("Incorrect password. Try again.");
    }
}