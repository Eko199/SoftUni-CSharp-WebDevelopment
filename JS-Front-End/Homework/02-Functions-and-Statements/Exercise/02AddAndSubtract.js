function addAndSubtract(x, y, z) {
    const sum = () => x + y;
    const subtract = () => sum() - z;

    console.log(subtract());
}