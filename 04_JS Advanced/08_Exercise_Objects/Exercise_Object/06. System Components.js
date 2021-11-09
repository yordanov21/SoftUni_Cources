function componentDB(data) {
    let parsedData = data.reduce((acc, componentData) => {
        let [name, component, subcomponent] = componentData.split('|').map(x => x.trim())

        if (!acc[name]) {
            acc[name] = { [component]: [subcomponent] };
            return acc
        }

        if (!acc[name][component]) {
            acc[name][component] = [subcomponent];
            return acc
        }

        acc[name][component] = [...acc[name][component], subcomponent];
        return acc;
    }, {})

    let sortSystems = Object.keys(parsedData).sort((a, b) => {
        if (Object.keys(parsedData[a]).length !== Object.keys(parsedData[b]).length) {
            return parsedData[b].length - parsedData[a].length
        }
        return a.localeCompare(b)


    })
    console.log(sortSystems);
}

componentDB([
    'SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security']
);