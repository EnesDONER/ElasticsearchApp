const puppeteer = require('puppeteer');
const { Client } = require('@elastic/elasticsearch');
const { v4: uuidv4 } = require('uuid');

const url = "https://www.sozcu.com.tr/";
const esClient = new Client({ node: 'http://localhost:9200' }); 
async function start() {
    const browser = await puppeteer.launch();
    const page = await browser.newPage();
    await page.goto(url);

    const newsItems = await page.$$eval(".news-card", (cards) => {
        return cards.map((card) => {
            const imgElement = card.querySelector('.img-holder img');
            const imageUrl = imgElement ? imgElement.getAttribute('src') : null;
            const textElement = card.querySelector('.news-card-footer');
            const text = textElement ? textElement.textContent.trim() : null;
            return { imageUrl, text };
        });
    });

    // Verileri Elasticsearch'e ekleme
    for (const item of newsItems) {
        await esClient.index({
            index: 'news', 
            document: {
                id: uuidv4(),
                imageUrl: item.imageUrl,
                text: item.text,
                timestamp: new Date()
            }
        });
    }

    await browser.close();
}

start().catch(console.log);
