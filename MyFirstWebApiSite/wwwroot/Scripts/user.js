
const register = async () => {
    console.log("aaa")
    const postData = {
        firstName: document.getElementById("firstName").value,
        lastName: document.getElementById("lastName").value,
        email: document.getElementById("userName").value,
        password: document.getElementById("password").value
    }
    console.log(postData.email)
    console.log(postData.firstName)
    console.log(postData.lastName)
    console.log(postData.password)
    const responsePost = await fetch('api/user', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(postData)
    });
    if (responsePost.ok) {
        const dataPost = await responsePost.json();
        console.log('Poast Data ', dataPost)
        window.location.href = "login.html";
    }
    else {
        alert("אופס, אחד או יותר מן הנתונים שגוי...")
    }
}

const login = async () => {
    console.log("bbb")
    const postData = {
        email: document.getElementById("userName").value,
        password: document.getElementById("password").value
    }
    console.log(postData.email)
    console.log(postData.password)
    const responsePost = await fetch('api/user/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(postData)
    });
    if (responsePost.status == 204) {
        alert("משתמש לא קיים")
    }
    else {
        if (responsePost.ok) {
                const dataPost = await responsePost.json();
                console.log('Poast Data ', dataPost)
                sessionStorage.setItem("user", JSON.stringify(dataPost));
                window.location.href = "home.html";
        }
        else {
        alert("שם משתמש או סיסמא אינם תקינים")
        }
    }
}

const update = async () => {
    console.log("ccc")
    const postData = {
        firstName: document.getElementById("firstName").value,
        lastName: document.getElementById("lastName").value,
        email: document.getElementById("userName").value,
        password: document.getElementById("password").value
    }
    console.log(postData.email)
    console.log(postData.password)
    const responsePost = await fetch(`api/user/${JSON.parse(sessionStorage.getItem("user")).userId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(postData)
    });
    if (responsePost.ok) {
            alert("הפרטים עודכנו בהצלחה");
            window.location.href = "login.html";
    }
    else {
        alert("אופס, אחד או יותר מן הנתונים שגוי...")
    }
}

const checkPassword = async () => {

    var strength = {
        0: "Worst",
        1: "Bad",
        2: "Weak",
        3: "Good",
        4: "Strong"
    }
    var password = document.getElementById("password").value;
    var progress = document.getElementById("password-strength-progress");
    var text = document.getElementById('password-strength-text');
    console.log(password)

    const responsePost = await fetch('api/user/checkPassword', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(password)
    });
    const dataPost = await responsePost.json();

    progress.value = dataPost

    if (password !== "") {
        text.innerHTML = "Strength: " + strength[dataPost];
    } else {
        text.innerHTML = "";
    }

}