function createCat(cats) {
    class Cat {
        constructor(name, age) {
            this.name = name;
            this.age = age;
        }
    
        meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    cats.forEach(c => {
        const [name, age] = c.split(" ");
        new Cat(name, age).meow();
    })
}