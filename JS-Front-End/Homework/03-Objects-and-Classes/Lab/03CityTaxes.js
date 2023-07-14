function cityTaxes(name, population, treasury) {
    return {
        name,
        population,
        treasury,
        taxRate: 10,

        collectTaxes() {
            this.treasury += this.population * this.taxRate;
            this.treasury = Math.floor(this.treasury);
        },

        applyGrowth(percentage) {
            this.population *= 1 + percentage / 100;
            this.population = Math.floor(this.population);
        },

        applyRecession(percentage) {
            this.treasury *= 1 - percentage / 100;
            this.treasury = Math.floor(this.treasury);
        }
    }
}