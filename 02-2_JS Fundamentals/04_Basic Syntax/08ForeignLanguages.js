function solve(country) {
    switch (country) {
        case 'USA':
        case 'England':
            console.log('English');
            break;
        case 'Spain':
        case 'Argentina':
        case 'Mexico':
            console.log('Spanish');
            break;

        default:
            console.log('unknown');
            break;
    }
}

//solve('USA');
//solve("USA");
//solve('Spain');
//solve("Mexico");
//solve('Germany');
//solve("Bulgaria");
