function scoreToHTMLTable(input) {
    let scoreArr = JSON.parse(input);

    let html = "<table>\n";

    html += "  <tr><th>name</th><th>score</th></tr>\n";

    function htmlEscape(text) {

        let replaced = new String(text);
        replaced = replaced.split('&').join('&amp;');
        replaced = replaced.split('<').join('&lt;');
        replaced = replaced.split('>').join('&gt;');
        replaced = replaced.split('"').join('&quot;');
        replaced = replaced.split('\'').join('&#39;');
        return replaced;
    }

    for (let score of scoreArr){
        html += `  <tr>`;
        html += `<td>${htmlEscape(score['name'])}</td>`;
        html += `<td>${htmlEscape(score['score'])}</td>`;
        html += `</tr>\n`;
    }
    return html + "</table>";
}

console.log(scoreToHTMLTable(['[{"name":"Pesho","score":479},{"name":"Gosho","score":205}]']));

