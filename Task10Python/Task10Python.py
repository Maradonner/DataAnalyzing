import nltk
from nltk.corpus import stopwords
from nltk.tokenize import word_tokenize
from nltk.stem.snowball import SnowballStemmer
from collections import Counter

nltk.download('punkt')
nltk.download('stopwords')

stemmer = SnowballStemmer("russian")
stop_words = set(stopwords.words("russian"))

def stem(word):
    return stemmer.stem(word)

with open('input.txt', 'r', encoding='cp1251') as file:
    text = file.read()

tokens = word_tokenize(text, language="russian")
filtered_tokens = [stem(word) for word in tokens if word.isalpha() and word.lower() not in stop_words]

frequency_dict = Counter(filtered_tokens)
sorted_frequency = sorted(frequency_dict.items(), key=lambda x: x[1], reverse=True)

with open('output.txt', 'w', encoding='cp1251') as output_file:
    for word, freq in sorted_frequency:
        output_file.write(f"{word}, {freq}\n")

print("\nSuccessfully saved into 'output.txt'")

