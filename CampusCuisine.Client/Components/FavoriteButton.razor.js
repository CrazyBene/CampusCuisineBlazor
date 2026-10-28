const storageKey = "campus-cuisine-favorites";

function loadFavorites() {
    return JSON.parse(localStorage.getItem(storageKey) ?? "[]");
}

export function isFavorite(recipeId) {
    return loadFavorites().includes(recipeId);
}

export function toggleFavorite(recipeId) {
    const favorites = loadFavorites();
    const index = favorites.indexOf(recipeId);

    if (index === -1) {
        favorites.push(recipeId);
    } else {
        favorites.splice(index, 1);
    }

    localStorage.setItem(storageKey, JSON.stringify(favorites));
    return index === -1;
}
