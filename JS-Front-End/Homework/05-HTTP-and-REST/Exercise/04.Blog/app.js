let posts;

function attachEvents() {
    document.getElementById("btnLoadPosts").addEventListener("click", loadPosts);
    document.getElementById("btnViewPost").addEventListener("click", viewPost);
}

async function loadPosts() {
    const select = document.getElementById("posts");

    posts = await (
        await fetch("http://localhost:3030/jsonstore/blog/posts")
    ).json();

    Object.entries(posts).forEach(([postKey, post]) => {
        const option = document.createElement("option");
        option.value = postKey;
        option.innerText = post.title.toUpperCase();
        select.appendChild(option);
    });
}

async function viewPost() {
    const post = posts[document.getElementById("posts").value];

    document.getElementById("post-title").innerText = post.title;
    document.getElementById("post-body").innerText = post.body;

    const commentSection = document.getElementById("post-comments");
    commentSection.innerHTML = "";

    const comments = Object.values(await (
        await fetch("http://localhost:3030/jsonstore/blog/comments")
    ).json()).filter(c => c.postId === post.id).map(c => c.text);

    comments.forEach(c => {
        const li = document.createElement("li");
        li.innerText = c;
        commentSection.appendChild(li);
    });
}

attachEvents();