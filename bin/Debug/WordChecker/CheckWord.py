import enchant
import sys

if __name__ == "__main__":
    validwords = enchant.Dict("en_US")
    print(validwords.check(sys.argv[1]))
