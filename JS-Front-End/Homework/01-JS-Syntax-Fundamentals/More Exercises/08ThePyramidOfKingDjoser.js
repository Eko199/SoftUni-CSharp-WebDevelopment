function solve(base, increment) {
    const floorVolume = (side) => side ** 2 * increment;

    const resourcesRequired = {
        stone: 0,
        marble: 0,
        lapis: 0,
        gold: 0
    };

    let height = 0;

    while (base > 0) {
        height++;

        if (base === 1 || base === 2) {
            resourcesRequired.gold += floorVolume(base);
            break;
        }

        const stoneToUse = floorVolume(base - 2);
        resourcesRequired.stone += stoneToUse;
        resourcesRequired[height % 5 === 0 ? "lapis" : "marble"] += floorVolume(base) - stoneToUse;

        base -= 2;
    }

    console.log(`Stone required: ${Math.ceil(resourcesRequired.stone)}
Marble required: ${Math.ceil(resourcesRequired.marble)}
Lapis Lazuli required: ${Math.ceil(resourcesRequired.lapis)}
Gold required: ${Math.ceil(resourcesRequired.gold)}
Final pyramid height: ${Math.floor(height * increment)}`);
}