import nltk
from nltk.corpus import stopwords
from nltk.tokenize import word_tokenize
from collections import Counter
import pymorphy2

nltk.download('punkt')
nltk.download('punkt_tab')
nltk.download('stopwords')

morph = pymorphy2.MorphAnalyzer()

stop_words = set(stopwords.words("russian"))

def normalize(word):
    return morph.parse(word)[0].normal_form

with open('input.txt', 'r', encoding='cp1251') as file:
    text = file.read()

tokens = word_tokenize(text, language="russian")
filtered_tokens = [normalize(word) for word in tokens if word.isalpha() and word.lower() not in stop_words]

frequency_dict = Counter(filtered_tokens)
sorted_frequency = sorted(frequency_dict.items(), key=lambda x: x[1], reverse=True)

with open('output.txt', 'w', encoding='cp1251') as output_file:
    for word, freq in sorted_frequency:
        output_file.write(f"{word}, {freq}\n")

print("\nSuccessfully saved into 'output.txt'")
